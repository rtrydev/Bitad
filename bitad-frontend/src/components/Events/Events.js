import EventCard from "../Cards/EventCard/EventCard";
import ExtendedEventCard from "../Cards/EventCard/ExtendedEventCard";
import Columns from "../UI/Columns";
import { DUMMY_AGENDAS } from "../../dummy-data/dummyData";
import styles from "./Events.module.css";

function Events(props) {
  const e = DUMMY_AGENDAS[0];
  const events = DUMMY_AGENDAS.map((event) => {
    return (
      <EventCard
        key={event.title}
        room={event.room}
        start={event.start}
        end={event.end}
        title={event.title}
      />
    );
  });
  return (
    <div className={styles.event}>
      <h3>{props.title}</h3>
      <ExtendedEventCard
        room={e.room}
        start={e.start}
        end={e.end}
        title={e.title}
        description={e.description}
      />
      <Columns columns="4">{events}</Columns>
    </div>
  );
}

export default Events;
