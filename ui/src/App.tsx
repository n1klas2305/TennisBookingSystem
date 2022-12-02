import DayView from "./DayView";
import "./App.css";
import { useState } from "react";
import type { Court } from "./types";
import { exampleCourts as courts } from "./example-courts";
import dayjs from "dayjs";

const germanFormat = "DD.MM.YYYY";
const englishFormat = "YYYY-MM-DD";

const days = courts.flatMap((court) =>
  court.bookings.map((booking) => booking.day)
);

const uniqueDays = [...new Set(days)];
let firstDay = uniqueDays.sort()[0];
if (dayjs(firstDay).isAfter(undefined)) {
  firstDay = dayjs().format(englishFormat);
}

function getCourtsForDay(day: string): Court[] {
  return courts.map((court) => ({
    ...court,
    bookings: court.bookings.filter((booking) => booking.day === day),
  }));
}

function App() {
  const [day, setDay] = useState(firstDay);

  const increaseDay = (days: number) =>
    setDay(dayjs(day).add(days, "day").format(englishFormat));

  return (
    <div
      style={{ display: "flex", flexDirection: "row", alignItems: "center" }}
    >
      <button
        disabled={day === firstDay}
        onClick={() => increaseDay(-1)}
        style={{ height: "fit-content" }}
      >
        ⬅️
        {day === firstDay
          ? "-"
          : dayjs(day).add(-1, "day").format(germanFormat)}
      </button>
      <div>
        <div>{dayjs(day).format(germanFormat)}</div>
        <div style={{ display: "flex", flexDirection: "row" }}>
          {getCourtsForDay(day).map((court, i) => (
            <DayView title={court.label} bookings={court.bookings} key={i} />
          ))}
        </div>
      </div>

      <button onClick={() => increaseDay(1)}>
        {dayjs(day).add(1, "day").format(germanFormat)} ➡️
      </button>
    </div>
  );
}

export default App;
