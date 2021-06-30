import Timelines from "../components/Timelines/Timelines";
import Container from "../components/UI/Container";
import { DUMMY_AGENDAS } from "../dummy-data/dummyData";

function Agenda() {
  return (
    <div style={{ marginTop: "200px" }}>
      <Container>
        <Timelines title="Wykłady" events={DUMMY_AGENDAS} />
      </Container>
    </div>
  );
}

export default Agenda;
