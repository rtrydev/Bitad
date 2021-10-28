import Card from "../Card";
import EntryDetails from "./EventDetails";
import EventSpeaker from "./EventSpeaker";
import styles from "./EventCard.module.css";
import typography from "../../../assets/css/Typography.module.css";

function EventCard(props) {
  const event = props.event;
  const { title, start, end, shortInfo, externalLink, speaker, room } = event;

  return (
    <Card id={title} className={styles["card--event"]}>
      <EntryDetails room={room} start={start} end={end} />
      <p className={styles.card__title}>{title}</p>
      {externalLink && (
        <a
          href={externalLink}
          target="_blank"
          className={`${typography["small-p"]} ${typography["text-align--right"]} ${styles["card__short-info"]}`}
        >
          ⇾ Zapisz się tutaj
        </a>
      )}
      {shortInfo && (
        <p
          className={`${typography["small-p"]} ${typography["text-align--right"]} ${styles["card__short-info"]}`}
        >
          {shortInfo}
        </p>
      )}
      <div>
        <EventSpeaker
          picture={speaker.picture}
          name={speaker.name}
          website={speaker.website}
          accentColor={speaker.accentColor}
          onClick={() => props.onProfileClick(event)}
        />
        {!!event.description ? (
          <button
            onClick={() => props.onClick(event)}
            className={`${typography["small-p"]} ${styles.card__button}`}
          >
            Dowiedz się więcej
          </button>
        ) : (
          <span className={styles["card__button--spacer"]} />
        )}
      </div>
    </Card>
  );
}

export default EventCard;
