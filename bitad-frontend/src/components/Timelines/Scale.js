import Entry from "./Entry";
import m from "moment";
import { isSameTime } from "./time-functions";

import styles from "./Scale.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

// TODO - Poprawic, samo isSameTime() jest zbyt mocnym sprawdzaniem
const findColumnsForEntry = (entryTime, times) => {
  return times.findIndex((time) => {
    // return isBeforeTime(m(entryTime), time) || isSameTime(m(entryTime), time);
    return isSameTime(m(entryTime), time);
  });
};

function Scale(props) {
  const entrys = props.entrys.map((entry) => {
    const startColumn = findColumnsForEntry(entry.start, props.times);
    const endColumn = findColumnsForEntry(entry.end, props.times);

    const style = {
      gridColumnStart: startColumn === -1 ? -1 : startColumn + 1,
      gridColumnEnd: endColumn === -1 ? -1 : endColumn + 1,
    };

    const classes = `${startColumn === -1 && styles["entry--break-left"]} ${
      endColumn === -1 && styles["entry--break-right"]
    } ${styles.pink}`;

    return (
      <Entry
        key={entry.title}
        showImage={startColumn !== -1}
        imageSrc={entry.speaker.picture}
        imageAlt={entry.speaker.name}
        to={`#${entry.title}`}
        style={style}
        className={classes}
      />
    );
  });
  return (
    <div className={`${styles.scale} ${bg["scale-background"]}`}>{entrys}</div>
  );
}

export default Scale;
