import type { Property } from "csstype";
import { useState } from "react";
import BookingModal from "./BookingModal";
import { Booking, Court } from "./types";

export interface DayViewProps {
  court: Court;
  day: string;
}

const hours = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21] as const;
export type HourType = typeof hours[number];

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

function App({ court, day }: DayViewProps) {
  const [modalIsOpen, setIsOpen] = useState(false);
  const [selectedBooking, setSelectedBooking] = useState<Booking | undefined>(
    undefined
  );
  const [selectedHour, setSelectedHour] = useState<HourType | undefined>(
    undefined
  );

  function openModal(booking: Booking | undefined, hour: HourType) {
    setIsOpen(true);
    setSelectedHour(hour);
    setSelectedBooking(booking);
  }

  function closeModal() {
    setIsOpen(false);
    setSelectedBooking(undefined);
    setSelectedHour(undefined);
  }

  return (
    <div>
      <h2>{court.label}</h2>
      <table>
        <tbody>
          {[
            ...hours.map((hour, i) => {
              const booking = getBookingFromHour(hour, court.bookings);

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
                    onClick={() => openModal(booking, hour)}
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
      {selectedHour ? (
        <BookingModal
          closeModal={closeModal}
          modalIsOpen={modalIsOpen}
          booking={selectedBooking}
          hour={selectedHour}
          day={day}
          courtId={court.courtId}
        />
      ) : null}
    </div>
  );
}

export default App;
