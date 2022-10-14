import DayView, { type Booking } from "./DayView";

interface Court {
  label: string;
  bookings: Booking[]
}

const courts: Court[] = [
  { label: "Platz 1", bookings: [
    { firstName: "Hans", startTime: 12, endTime: 14, type: "BOOKED" },
    { startTime: 17, endTime: 18, type: "BLOCKED" },
  ] },
  { label: "Platz 2", bookings: [] },
  { label: "Platz 3", bookings: [] },
  { label: "Platz 4", bookings: [] },
];

function App() {
  return courts.map((court) => (
    <DayView title={court.label} bookings={court.bookings} />
  ));
}

export default App;
