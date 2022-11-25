import DayView, { type Booking } from "./DayView";
import "./App.css";
import type { Court } from "./types";

const courts: Court[] = [
  {
    label: "Platz 1",
    bookings: [
      { firstName: "Hans", startTime: 12, endTime: 14, type: "BOOKED" },
      { startTime: 17, endTime: 18, type: "BLOCKED" },
    ],
  },
  { label: "Platz 2", bookings: [] },
  { label: "Platz 3", bookings: [] },
  { label: "Platz 4", bookings: [] },
];

function App() {
  return (
    <div style={{ display: "flex", flexDirection: "row" }}>
      {courts.map((court, i) => (
        <DayView title={court.label} bookings={court.bookings} key={i} />
      ))}
    </div>
  );
}

export default App;
