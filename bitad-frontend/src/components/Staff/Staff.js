import StaffCard from "../Cards/StaffCard";
import Columns from "../UI/Columns";
import { DUMMY_STAFF } from "../../dummy-data/dummyData";

function Staff() {
  const staff = DUMMY_STAFF.map((e) => (
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
