import "./App.css";

export interface Booking {
  firstName?: string;
  lastName?: string;
  startTime: number;
  endTime: number;
  type: "BOOKED" | "BLOCKED";
}

export interface DayViewProps {
  title: string;
  bookings: Booking[];
}

function getBookingFromHour(
  hour: number,
  days: Booking[]
): Booking | undefined {
  const booking = days.find(
    (day) =>
      day.startTime <= hour && day.endTime > hour
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
                    {booking?.firstName} {booking?.lastName}
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
