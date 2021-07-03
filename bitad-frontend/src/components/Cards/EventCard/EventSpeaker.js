import styles from "./EventSpeaker.module.css";
import typography from "../../../assets/css/Typography.module.css";
import layout from "../../../assets/css/Layout.module.css";

function EventSpeaker(props) {
  return (
    <div className={styles["event-speaker"]}>
      <img
        src={props.picture}
        alt={props.name}
        className={layout["image--circle"]}
      />
      <div className={styles["event-speaker__details"]}>
        <span className={styles.details__name}>{props.name}</span>
        <span className={typography["small-p"]}>{props.website}</span>
      </div>
    </div>
  );
}

export default EventSpeaker;
