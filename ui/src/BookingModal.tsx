import Modal from "react-modal";

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

export default (props: { closeModal: () => void, modalIsOpen: boolean }) => (
  <Modal
    isOpen={props.modalIsOpen}
    onRequestClose={props.closeModal}
    style={customStyles}
    contentLabel="Buchung"
  >
    <div>Zeitraum: Freitag, 07.02.2022</div>
    <div>10:00 - 11.00 Uhr</div>
    <form>
      <label>
        Vorname:
        <input type={"text"} />
      </label>
      <label>
        Nachname:
        <input type={"text"} />
      </label>
      <button type={"submit"}>buchen</button>
      <button type={"reset"} onClick={props.closeModal}>
        abbrechen
      </button>
    </form>
  </Modal>
);
