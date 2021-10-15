import styles from "./EventCard.module.css";
import m from "moment";
import typography from "../../../assets/css/Typography.module.css";

function EventDetails({ room, start, end }) {
  return (
    <div className={styles.card__details}>
      {room && (
        <span className={`${styles.details__room} ${typography["small-p"]}`}>
          {room}
        </span>
      )}
      {(start || end) && (
        <span className={`${styles.details__time} ${typography["small-p"]}`}>
          {`${m(start).format("HH:mm")}-${m(end).format("HH:mm")}`}
        </span>
      )}
    </div>
  );
}

export default EventDetails;
