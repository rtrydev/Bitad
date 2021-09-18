import Timelines from "../../components/Timelines/Timelines";
import styles from "./TimelinesPart.module.css";

function TimelinesPart(props) {
  return (
    <div className={styles.timelines}>
      <Timelines title="Wykłady" events={props.agendas} timelineCount={3} />
      <Timelines title="Warsztaty" events={props.workshops} />
    </div>
  );
}

export default TimelinesPart;
