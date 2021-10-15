import Entry from "./Entry";
import entryStyles from "./Entry.module.css";
import m from "moment";
import { isSameTime, isAfterTime, isBeforeTime } from "./time-functions";
import styles from "./Scale.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import {
  accentColorToClassName,
  setNoScroll,
} from "../../hooks/custom-functions";
import ExtendedEventCard from "../Cards/EventCard/ExtendedEventCard";
import { useState, useEffect } from "react";

/**
 *
 * @param {m[]} entryTime
 * @param {m[]} times
 * @param {Boolean} startsFindingFromBeginning
 * @returns
 */
const findColumnsForEntry = (
  entryTime,
  times,
  startsFindingFromBeginning = true
) => {
  if (startsFindingFromBeginning) {
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
  const [clickedEntry, setClickedEntry] = useState({});
  const [isShowExtendedCard, setIsShowExtendedCard] = useState(false);

  useEffect(() => {
    setNoScroll(isShowExtendedCard);
  }, [isShowExtendedCard]);

  const handleOpenExtendedCard = (e) => {
    setIsShowExtendedCard(true);
    setClickedEntry(e);
  };

  const handleCloseExtendedCard = () => {
    setIsShowExtendedCard(false);
  };

  const entries = props.entries.map((entry, index) => {
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
    } ${accentColorToClassName(entry.speaker.accentColor)}`;

    return (
      <Entry
        key={index}
        showImage={startColumn !== -1}
        imageSrc={entry.speaker.picture}
        imageAlt={entry.speaker.name}
        style={style}
        className={classes}
        onClick={() => handleOpenExtendedCard(entry)}
      />
    );
  });
  return (
    <>
      <div className={`${styles.scale} ${bg["scale-background"]}`}>
        {entries}
      </div>
      {isShowExtendedCard && (
        <ExtendedEventCard
          {...clickedEntry}
          onClick={handleCloseExtendedCard}
        />
      )}
    </>
  );
}

export default Scale;
