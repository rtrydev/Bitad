import StaffCard from "../Cards/StaffCard";
import Columns from "../UI/Columns";

function Staff(props) {
  const staff = props.staff.map((e) => (
    <StaffCard
      key={e.name}
      picture={e.picture}
      name={e.name}
      degree={e.degree}
      description={e.description}
    />
  ));
  return <Columns columns="3">{staff}</Columns>;
}

export default Staff;
