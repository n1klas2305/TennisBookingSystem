import { useState } from "react";
import Modal from "react-modal";
import type { Booking, HourType } from "./DayView";

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
  const [firstName, setFirstName] = useState(props.booking?.firstName ?? "");
  const [lastName, setLastName] = useState(props.booking?.lastName ?? "");

  return (
    <Modal
      isOpen={props.modalIsOpen}
      onRequestClose={props.closeModal}
      style={customStyles}
      contentLabel="Buchung"
    >
      <div>Zeitraum: Freitag, 07.02.2022</div>
      <div>
        {props.hour}:00 - {props.hour + 1}.00 Uhr
      </div>
      <form>
        <label>
          Vorname:
          <input
            type="text"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
        </label>
        <label>
          Nachname:
          <input
            type="text"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />
        </label>
        <button type="submit">buchen</button>
        <button type="reset" onClick={props.closeModal}>
          abbrechen
        </button>
      </form>
    </Modal>
  );
};
