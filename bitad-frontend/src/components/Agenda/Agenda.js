import { DUMMY_AGENDAS } from "../../dummy-data/dummyData";
import Timelines from "../Timelines/Timelines";
import Events from "../Events/Events";

function Agenda() {
  return (
    <div>
      <Timelines />
      <Events />
    </div>
  );
}

export default Agenda;
