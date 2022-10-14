import DayView, { type DayViewProps } from "./DayView";

const mockData: DayViewProps["bookings"] = [
  { text: "Buchung", startTime: 12, endTime: 14, type: "BOOKED" },
];

function App() {
  return <DayView title="Platz 1" bookings={mockData} />;
}

export default App;
