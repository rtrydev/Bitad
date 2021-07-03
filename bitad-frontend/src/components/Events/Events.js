import EventCard from "../Cards/EventCard/EventCard";
import Columns from "../UI/Columns";
import { DUMMY_AGENDAS } from "../../dummy-data/dummyData";
import styles from "./Events.module.css";

function Events(props) {
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
      <h4>{props.title}</h4>
      <Columns columns="4">{events}</Columns>
    </div>
  );
}

export default Events;
