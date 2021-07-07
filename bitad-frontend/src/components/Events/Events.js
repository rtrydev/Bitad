import EventCard from "../Cards/EventCard/EventCard";
import ExtendedEventCard from "../Cards/EventCard/ExtendedEventCard";
import Columns from "../UI/Columns";
import { DUMMY_AGENDAS } from "../../dummy-data/dummyData";
import styles from "./Events.module.css";
import { useState, useEffect } from "react";
import { setNoScroll } from "../../hooks/custom-functions";

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

  const e = DUMMY_AGENDAS[0];
  const events = DUMMY_AGENDAS.map((event) => {
    return (
      <EventCard key={event.title} event={event} onClick={openExtendedCard} />
    );
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
