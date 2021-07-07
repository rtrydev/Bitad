import Events from "../../components/Events/Events";
import { DUMMY_AGENDAS } from "../../dummy-data/dummyData";

function EventsPart() {
  return (
    <div>
      <Events title="Wykłady" events={DUMMY_AGENDAS} />
      {/* <Events title="Warsztaty" events={DUMMY_AGENDAS} /> */}
    </div>
  );
}

export default EventsPart;
