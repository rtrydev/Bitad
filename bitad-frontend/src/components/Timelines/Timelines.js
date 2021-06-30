import Timeline from "./Timeline";
import m from "moment";
import { filterEventsByTime } from "./time-functions";

import styles from "./Timelines.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function Timelines(props) {
  const firstTimelineStart = m({ hour: 8, minute: 0, second: 0 });
  const secondTimelineStart = m({ hour: 12, minute: 30, second: 0 });

  return (
    <div>
      <h4>{props.title}</h4>
      <div className={`${styles.timelines} ${bg["gradient-background"]}`}>
        <div className={styles.timelines__scroll}>
          <Timeline
            startTime={firstTimelineStart}
            events={filterEventsByTime(props.events, firstTimelineStart)}
          />
          <Timeline
            startTime={secondTimelineStart}
            events={filterEventsByTime(props.events, secondTimelineStart)}
          />
        </div>
      </div>
    </div>
  );
}

export default Timelines;
