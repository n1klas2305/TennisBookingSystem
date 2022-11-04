import type { Property } from "csstype";
import { useState } from "react";
import BookingModal from "./BookingModal";

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
    (day) => day.startTime <= hour && day.endTime > hour
  );
  return booking;
}

function getBackgroundColor(
  booking: Booking | undefined
): Property.BackgroundColor {
  if (booking == null) {
    return "";
  } else if (booking.type === "BLOCKED") {
    return "red";
  }
  return "grey";
}

function App(props: DayViewProps) {
  const hours = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21] as const;

  const [modalIsOpen, setIsOpen] = useState(false);

  function openModal() {
    setIsOpen(true);
  }

  function closeModal() {
    setIsOpen(false);
  }

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
                      backgroundColor: getBackgroundColor(booking),
                      minWidth: "8rem",
                      height: "2rem",
                    }}
                    onClick={openModal}
                  >
                    {booking?.type === "BLOCKED" ? "gesperrt" : ""}
                    {booking?.firstName} {booking?.lastName}
                  </td>
                </tr>
              );
            }),
          ]}
        </tbody>
      </table>

      <div style={{ textAlign: "left" }}>Uhr</div>

      <BookingModal closeModal={closeModal} modalIsOpen={modalIsOpen} />
    </div>
  );
}

export default App;
