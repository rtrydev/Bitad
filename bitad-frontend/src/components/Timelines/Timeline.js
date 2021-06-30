import Scale from "./Scale";
import TimesBar from "./TimesBar";
import { createTimes } from "./time-functions";

import styles from "./Timeline.module.css";

function Timeline(props) {
  return (
    <div className={styles.timeline}>
      <TimesBar className={styles.time} times={createTimes(props.startTime)} />
      <Scale entrys={props.events} times={createTimes(props.startTime, 5)} />
    </div>
  );
}

export default Timeline;
