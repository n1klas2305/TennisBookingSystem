import "./App.css";

export interface DayViewProps {
  title: string;
  bookings: {
    text: string;
    startTime: number;
    endTime: number;
    type: "BOOKED" | "BLOCKED";
  }[];
}

function getBookingFromHour(
  hour: number,
  days: DayViewProps["bookings"]
): DayViewProps["bookings"][number] | undefined {
  const booking = days.find(
    (day) =>
      day.startTime === hour || (day.startTime < hour && day.endTime > hour)
  );
  return booking;
}

function App(props: DayViewProps) {
  const hours = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21] as const;

  return (
    <div>
      <h2>{props.title}</h2>

      <table>
        <tbody>
          {[
            ...hours.map((hour, i) => {
              const booking = getBookingFromHour(hour, props.bookings);

              return (
                <tr key={i}>
                  <td>{hour}</td>
                  <td
                    style={{
                      border: "solid 2px white",
                      backgroundColor: booking != null ? "grey" : "",
                    }}
                  >
                    {booking?.text}
                  </td>
                </tr>
              );
            }),
          ]}
        </tbody>
      </table>

      <div>Uhr</div>
    </div>
  );
}

export default App;
