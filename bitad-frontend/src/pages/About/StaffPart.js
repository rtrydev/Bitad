import { Fragment } from "react";
import typography from "../../assets/css/Typography.module.css";
import Staff from "../../components/Staff/Staff";

function StaffPart() {
  return (
    <Fragment>
      <h2 className={typography["text-align--center"]}>Organizatorzy</h2>
      <p className={typography["text-align--center"]}>
        Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o to, aby
        to piątkowe spotkanie było przede wszystkim. Mile spędzonym czasem,
        dlatego wzbogaciliśmy konferencję o dodatkowe atrakcje.
      </p>
      <Staff />
    </Fragment>
  );
}

export default StaffPart;
