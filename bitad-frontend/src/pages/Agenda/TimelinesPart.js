import Timelines from "../../components/Timelines/Timelines";
import { DUMMY_AGENDAS } from "../../dummy-data/dummyData";
import styles from "./TimelinesPart.module.css";

function TimelinesPart() {
  return (
    <div className={styles.timelines}>
      <Timelines title="Wykłady" events={DUMMY_AGENDAS} />
      <Timelines title="Warsztaty" events={DUMMY_AGENDAS} />
    </div>
  );
}

export default TimelinesPart;
