import DayView from "./DayView";
import "./App.css";
import { useEffect, useState } from "react";
import type { Court } from "./types";
import dayjs from "dayjs";

const germanFormat = "DD.MM.YYYY";
const englishFormat = "YYYY-MM-DD";

function App() {
  const [day, setDay] = useState(dayjs().format(englishFormat));
  const [firstDay, setFirstDay] = useState(dayjs().format(englishFormat));
  const [courts, setCourts] = useState<Court[]>([]);

  const increaseDay = (days: number) =>
    setDay(dayjs(day).add(days, "day").format(englishFormat));

  useEffect(() => {
    const load = async () => {
      const response = await fetch("http://localhost:4000/courts");
      const data = (await response.json()) as Court[];

      const days = data.flatMap((court) =>
        court.bookings.map((booking) => booking.date)
      );

      const uniqueDays = [...new Set(days)];
      if (dayjs(firstDay).isAfter(undefined)) {
        setFirstDay(dayjs().format(englishFormat));
      } else {
        setFirstDay(uniqueDays.sort()[0]);
      }

      setCourts(data);
    };
    load();
  }, []);

  function getCourtsForDay(day: string): Court[] {
    return courts.map((court) => ({
      ...court,
      bookings: court.bookings.filter((booking) =>
        dayjs(booking.date).isSame(day, "day")
      ),
    }));
  }

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
