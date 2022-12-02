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
  hour: HourType;
  closeModal: () => void;
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
  return (
    <Modal
      isOpen={props.modalIsOpen}
      onRequestClose={close}
      style={customStyles}
      contentLabel="Buchung"
    >
      <div>Zeitraum: Freitag, 07.02.2022</div>
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
        <button type="submit">{props.booking ? "stornieren" : "buchen"}</button>
        <button type="reset" onClick={close}>
          abbrechen
        </button>
      </form>
    </Modal>
  );
};
