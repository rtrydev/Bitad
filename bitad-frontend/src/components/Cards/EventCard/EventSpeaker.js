import styles from "./EventSpeaker.module.css";
import typography from "../../../assets/css/Typography.module.css";
import layout from "../../../assets/css/Layout.module.css";
import {
  accentColorToClassName,
  parsePicture,
} from "../../../hooks/custom-functions";

function EventSpeaker(props) {
  return (
    <div
      className={`${styles["event-speaker"]} ${accentColorToClassName(
        props.accentColor
      )} ${props.onClick && styles["event-speaker_clickable"]}`}
      onClick={props.onClick}
    >
      <img
        src={parsePicture(props.picture)}
        alt={props.name}
        className={layout["image--circle"]}
      />
      <div className={styles["event-speaker__details"]}>
        <span
          className={`${styles.details__name} ${styles["details__name--ellipsis"]}`}
        >
          {props.name}
        </span>
        <span className={typography["small-p"]}>{props.website}</span>
      </div>
    </div>
  );
}

export default EventSpeaker;
