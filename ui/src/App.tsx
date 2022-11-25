import DayView from "./DayView";
import "./App.css";
import { useState } from "react";
import type { Court } from "./types";
import { exampleCourts as courts } from "./example-courts";

const days = courts.flatMap((court) =>
  court.bookings.map((booking) => booking.day)
);

const uniqueDays = [...new Set(days)];

function getCourtsForDay(day: string): Court[] {
  return courts.map((court) => ({
    ...court,
    bookings: court.bookings.filter((booking) => booking.day === day),
  }));
}

function App() {
  const [daysIndex, setDayIndex] = useState<number>(0);
  console.log("render App.tsx");

  return (
    <>
      <button
        disabled={daysIndex === 0}
        onClick={() => setDayIndex(daysIndex - 1)}
      >
        ⬅️
      </button>
      <div>{uniqueDays[daysIndex]}</div>
      <div style={{ display: "flex", flexDirection: "row" }}>
        {getCourtsForDay(uniqueDays[daysIndex]).map((court, i) => (
          <DayView title={court.label} bookings={court.bookings} key={i} />
        ))}
      </div>
      <button
        disabled={daysIndex === uniqueDays.length - 1}
        onClick={() => setDayIndex(daysIndex + 1)}
      >
        ➡️
      </button>
    </>
  );
}

export default App;
