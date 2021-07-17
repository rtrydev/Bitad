import Events from "../../components/Events/Events";

function EventsPart(props) {
  return (
    <div>
      <Events title="Wykłady" events={props.agendas} />
      <Events title="Warsztaty" events={props.workshops} />
    </div>
  );
}

export default EventsPart;
