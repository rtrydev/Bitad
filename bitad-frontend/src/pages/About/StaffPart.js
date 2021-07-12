import { Fragment } from "react";
import typography from "../../assets/css/Typography.module.css";
import Staff from "../../components/Staff/Staff";

function StaffPart() {
  return (
    <Fragment>
      <h2 className={typography["text-align--center"]}>Organizatorzy</h2>
      <p className={typography["text-align--center"]}>
        Musieliśmy się tutaj wpisać. Przygotowaliśmy konferencję dla Was i
        serdecznie wszystkich na nią zapraszamy. Będziecie mogli z nami się
        spotkać i porozmawiać podczas Bitadu.
      </p>
      <Staff />
    </Fragment>
  );
}

export default StaffPart;
