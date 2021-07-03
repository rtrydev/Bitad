import styles from "./EventCard.module.css";
import m from "moment";
import typography from "../../../assets/css/Typography.module.css";

function EventDetails(props) {
  return (
    <div className={styles.card__details}>
      <span className={`${styles.details__room} ${typography["small-p"]}`}>
        {props.room}
      </span>
      <span className={`${styles.details__time} ${typography["small-p"]}`}>
        {`${m(props.start).format("HH:mm")}-${m(props.end).format("HH:mm")}`}
      </span>
    </div>
  );
}

export default EventDetails;
