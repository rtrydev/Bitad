import Card from "../Card";
import EntryDetails from "./EventDetails";
import EventSpeaker from "./EventSpeaker";
import styles from "./ExtendedEventCard.module.css";
import typography from "../../../assets/css/Typography.module.css";

function ExtendedEventCard(props) {
  return (
    <Card className={styles["card--extended-event"]}>
      <div className={styles.card__header}>
        <EntryDetails room={props.room} start={props.start} end={props.end} />
        <EventSpeaker
          picture="https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1050&q=80"
          name="Jan Kowalski"
          website="Test"
        />
      </div>
      <div className={styles.card__main}>
        <h3>{props.title}</h3>
        <p>{props.description}</p>
      </div>
      <div className={typography["text-align--center"]}>
        <button className={typography.button}>Zamknij</button>
      </div>
    </Card>
  );
}

export default ExtendedEventCard;
