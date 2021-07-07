import Card from "../Card";
import EntryDetails from "./EventDetails";
import EventSpeaker from "./EventSpeaker";
import styles from "./EventCard.module.css";
import typography from "../../../assets/css/Typography.module.css";

function EventCard(props) {
  const event = props.event;
  return (
    <Card id={event.title} className={styles["card--event"]}>
      <EntryDetails room={event.room} start={event.start} end={event.end} />
      <p className={styles.card__title}>{event.title}</p>
      <div>
        <EventSpeaker
          picture={event.speaker.picture}
          name={event.speaker.name}
          website={event.speaker.website}
          accentColor={event.accentColor}
        />
        <button
          onClick={() => props.onClick(event)}
          className={`${typography["small-p"]} ${styles.card__button}`}
        >
          Dowiedz się więcej
        </button>
      </div>
    </Card>
  );
}

export default EventCard;
