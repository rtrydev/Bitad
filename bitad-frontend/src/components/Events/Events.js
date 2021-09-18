import EventCard from "../Cards/EventCard/EventCard";
import ExtendedEventCard from "../Cards/EventCard/ExtendedEventCard";
import Columns from "../UI/Columns";
import { useState, useEffect } from "react";
import { setNoScroll } from "../../hooks/custom-functions";

import styles from "./Events.module.css";

function Events(props) {
  const [isShowExtendedCard, setIsShowExtendedCard] = useState(false);
  const [clickedEvent, setClickedEvent] = useState({});

  useEffect(() => {
    setNoScroll(isShowExtendedCard);
  }, [isShowExtendedCard]);

  const openExtendedCard = (e) => {
    setIsShowExtendedCard(true);
    setClickedEvent(e);
  };

  const closeExtendedCard = () => {
    setIsShowExtendedCard(false);
  };

  const events = props.events.map((event, index) => {
    return <EventCard key={index} event={event} onClick={openExtendedCard} />;
  });
  return (
    <div className={styles.event}>
      <h3>{props.title}</h3>
      {isShowExtendedCard && (
        <ExtendedEventCard event={clickedEvent} onClick={closeExtendedCard} />
      )}
      <Columns columns="4">{events}</Columns>
    </div>
  );
}

export default Events;
