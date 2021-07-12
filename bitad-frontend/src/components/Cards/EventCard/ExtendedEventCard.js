import React, { Fragment } from "react";
import ReactDOM from "react-dom";
import Card from "../Card";
import EntryDetails from "./EventDetails";
import EventSpeaker from "./EventSpeaker";
import styles from "./ExtendedEventCard.module.css";
import typography from "../../../assets/css/Typography.module.css";

const Backdrop = (props) => {
  return <div onClick={props.onClick} className={styles["backdrop"]} />;
};

const Overlay = (props) => {
  const event = props.event;
  return (
    <Card className={styles["card--extended-event"]}>
      <div className={styles.card__header}>
        <EntryDetails room={event.room} start={event.start} end={event.end} />
        <EventSpeaker
          picture={event.speaker.picture}
          name={event.speaker.name}
          website={event.speaker.website}
        />
      </div>
      <div className={styles.card__main}>
        <h3>{event.title}</h3>
        <p>{event.description}</p>
      </div>
      <div className={typography["text-align--center"]}>
        <button onClick={props.onClick} className={typography.button}>
          Zamknij
        </button>
      </div>
    </Card>
  );
};

function ExtendedEventCard(props) {
  return (
    <Fragment>
      {ReactDOM.createPortal(
        <Backdrop onClick={props.onClick} />,
        document.getElementById("backdrop-root")
      )}
      {ReactDOM.createPortal(
        <Overlay event={props.event} onClick={props.onClick} />,
        document.getElementById("overlay-root")
      )}
    </Fragment>
  );
}

export default ExtendedEventCard;
