import Timeline from "./Timeline";
import m from "moment";
import { filterEventsByTime } from "./time-functions";

import styles from "./Timelines.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function Timelines({ title, events = [], timelineCount = 2 }) {
  const firstTimelineStart = m({ hour: 8, minute: 0, second: 0 });
  const duration = 270;
  const timelines = [];

  for (let i = 0; i < timelineCount; i++) {
    const timelineDuration = duration * i;
    const startTime = m(firstTimelineStart).add(timelineDuration, "minutes");
    timelines.push(
      <Timeline
        key={i}
        startTime={startTime}
        events={filterEventsByTime(events, startTime)}
      />
    );
  }

  return (
    <div>
      <h4>{title}</h4>
      <div className={`${styles.timelines} ${bg["gradient-background"]}`}>
        <div className={styles.timelines__scroll}>{timelines}</div>
      </div>
    </div>
  );
}

export default Timelines;
