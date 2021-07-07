import Entry from "./Entry";
import entryStyles from "./Entry.module.css";
import m from "moment";
import { isSameTime, isAfterTime, isBeforeTime } from "./time-functions";

import styles from "./Scale.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import { accentColorToClassName } from "../../hooks/custom-functions";

/**
 *
 * @param {m[]} entryTime
 * @param {m[]} times
 * @param {Boolean} startsFindingFromBegining
 * @returns
 */
const findColumnsForEntry = (
  entryTime,
  times,
  startsFindingFromBegining = true
) => {
  if (startsFindingFromBegining) {
    return times.findIndex((time) => {
      return isBeforeTime(m(entryTime), time) || isSameTime(m(entryTime), time);
    });
  }
  // findIndex but starts from end of array
  for (let i = times.length - 1; i >= 0; i--) {
    if (
      isAfterTime(m(entryTime), times[i]) ||
      isSameTime(m(entryTime), times[i])
    )
      return i;
  }
  return -1;
};

function Scale(props) {
  const entrys = props.entrys.map((entry) => {
    const startColumn = findColumnsForEntry(entry.start, props.times, false);
    const endColumn = findColumnsForEntry(entry.end, props.times);

    const style = {
      gridColumnStart: startColumn === -1 ? -1 : startColumn + 1,
      gridColumnEnd: endColumn === -1 ? -1 : endColumn + 1,
    };

    const classes = `${
      startColumn === -1 && entryStyles["entry--break-left"]
    } ${
      endColumn === -1 && entryStyles["entry--break-right"]
    } ${accentColorToClassName(entry.accentColor)}`;

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
