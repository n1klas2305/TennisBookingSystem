import dayjs from "dayjs";
import { useEffect, useState } from "react";
import Modal from "react-modal";
import type { HourType } from "./DayView";
import type { Booking } from "./types";

const customStyles: Modal.Styles = {
  content: {
    top: "50%",
    left: "50%",
    right: "auto",
    bottom: "auto",
    marginRight: "-50%",
    transform: "translate(-50%, -50%)",
    backgroundColor: "black",
  },
  overlay: { backgroundColor: "rgba(255, 255, 255, 0.5)" },
};

type BookingModalProps = {
  booking: Booking | undefined;
  courtId: string;
  hour: HourType;
  day: string;
  closeModal: (type?: "new" | "deleted") => void;
  modalIsOpen: boolean;
};

export default (props: BookingModalProps) => {
  const getForm = () => ({
    firstName: props.booking?.firstName ?? "",
    lastName: props.booking?.lastName ?? "",
  });

  const [form, setForm] = useState(getForm());

  useEffect(() => {
    setForm(getForm());
  }, [props]);

  const close = () => {
    props.closeModal();
  };

  const submit = async () => {
    if (form.firstName === "" || form.lastName === "") {
      alert("Fehlende Daten");
    } else if (props.booking == null) {
      // save new booking
      await fetch("http://localhost:4000/bookings", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          CourtId: props.courtId,
          Type: "BOOKED",
          FirstName: form.firstName,
          LastName: form.lastName,
          Date: props.day,
          StartTime: props.hour,
          EndTime: props.hour + 1,
        }),
      });
      props.closeModal("new");
    } else if (props.booking != null) {
      // remove booking
      await fetch(`http://localhost:4000/bookings/${props.booking.bookingId}`, {
        method: "DELETE",
      });
      props.closeModal("deleted");
    }
  };

  return (
    <Modal
      isOpen={props.modalIsOpen}
      onRequestClose={close}
      style={customStyles}
      contentLabel="Buchung"
    >
      <div>Zeitraum: {dayjs(props.day).format("DD.MM.YYYY")}</div>
      <div>
        {props.hour}:00 - {props.hour + 1}.00 Uhr
      </div>
      <form
        onClick={(e) => e.preventDefault()}
        style={{ display: "flex", flexDirection: "column" }}
      >
        <label>
          Vorname:
          <input
            type="text"
            value={form.firstName}
            onChange={(e) => setForm({ ...form, firstName: e.target.value })}
          />
        </label>
        <label>
          Nachname:
          <input
            type="text"
            value={form.lastName}
            onChange={(e) => setForm({ ...form, lastName: e.target.value })}
          />
        </label>
        <button type="submit" onClick={submit}>
          {props.booking ? "stornieren" : "buchen"}
        </button>
        <button type="reset" onClick={close}>
          abbrechen
        </button>
      </form>
    </Modal>
  );
};
