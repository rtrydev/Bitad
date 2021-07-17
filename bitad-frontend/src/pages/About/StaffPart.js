import { Fragment } from "react";
import typography from "../../assets/css/Typography.module.css";
import Staff from "../../components/Staff/Staff";
import { useGetRequest } from "../../hooks/http-requests";
import Loading from "../../components/UI/Loading";

function StaffPart() {
  const { response, isLoading } = useGetRequest("/Staff/GetStaff");
  return (
    <Fragment>
      <h2 className={typography["text-align--center"]}>Organizatorzy</h2>
      <p className={typography["text-align--center"]}>
        Musieliśmy się tutaj wpisać. Przygotowaliśmy konferencję dla Was i
        serdecznie wszystkich na nią zapraszamy. Będziecie mogli z nami się
        spotkać i porozmawiać podczas Bitadu.
      </p>
      {isLoading ? <Loading fontSize="120px" /> : <Staff staff={response} />}
    </Fragment>
  );
}

export default StaffPart;
