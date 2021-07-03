import Card from "../Card";
import EntryDetails from "./EventDetails";
import EventSpeaker from "./EventSpeaker";
import { Link } from "react-router-dom";
import styles from "./EventCard.module.css";
import typography from "../../../assets/css/Typography.module.css";

function EventCard(props) {
  return (
    <Card id={props.title} className={styles["card--event"]}>
      <EntryDetails room={props.room} start={props.start} end={props.end} />
      <p className={styles.card__title}>{props.title}</p>
      <div>
        <EventSpeaker
          picture="https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1050&q=80"
          name="Jan Kowalski"
          website="Test"
        />
        <div
          className={`${typography["small-p"]} ${typography["text-align--center"]}`}
        >
          <Link to="/">Dowiedz się więcej</Link>
        </div>
      </div>
    </Card>
  );
}

export default EventCard;
