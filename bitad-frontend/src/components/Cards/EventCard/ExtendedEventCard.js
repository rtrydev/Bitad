import React, { Fragment } from "react";
import ReactDOM from "react-dom";
import Card from "../Card";
import EntryDetails from "./EventDetails";
import EventSpeaker from "./EventSpeaker";
import styles from "./ExtendedEventCard.module.css";
import typography from "../../../assets/css/Typography.module.css";
import NewLineText from "../../NewLineText/NewLineText";

const Backdrop = ({ onClick }) => {
  return <div onClick={onClick} className={styles["backdrop"]} />;
};

const Overlay = ({
  title,
  description,
  speaker,
  room,
  start,
  end,
  onClick,
  shortInfo,
  externalLink,
}) => {
  return (
    <Card className={styles["card--extended-event"]}>
      <div className={styles.card__header}>
        <EntryDetails room={room} start={start} end={end} />
        <EventSpeaker
          picture={speaker.picture}
          name={speaker.name}
          website={speaker.website}
          accentColor={speaker.accentColor}
        />
      </div>
      <div className={styles.card__main}>
        <h3>{title}</h3>
        {externalLink && (
          <p>
            <a href={externalLink} target="_blank" rel="noreferrer">
              ⇾ Zapisz się tutaj
            </a>
          </p>
        )}
        {shortInfo && <p>{shortInfo}</p>}
        <NewLineText text={description} />
      </div>
      <div className={typography["text-align--center"]}>
        <button onClick={onClick} className={typography.button}>
          Zamknij
        </button>
      </div>
    </Card>
  );
};

function ExtendedEventCard({
  onClick,
  title,
  description,
  speaker,
  shortInfo,
  externalLink,
  room,
  start,
  end,
}) {
  return (
    <Fragment>
      {ReactDOM.createPortal(
        <Backdrop onClick={onClick} />,
        document.getElementById("backdrop-root")
      )}
      {ReactDOM.createPortal(
        <Overlay
          title={title}
          description={description}
          speaker={speaker}
          room={room}
          start={start}
          shortInfo={shortInfo}
          externalLink={externalLink}
          end={end}
          onClick={onClick}
        />,
        document.getElementById("overlay-root")
      )}
    </Fragment>
  );
}

export default ExtendedEventCard;
