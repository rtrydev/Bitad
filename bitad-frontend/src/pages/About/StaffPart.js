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
        Jako zespół dokładamy wszelkich starań, aby ta konferencja była wspólną
        wspaniałą przygodą pełną niesamowitych wrażeń. Dlatego wszystkich
        serdecznie zapraszamy oraz służymy pomocą 😃
      </p>
      {isLoading ? <Loading fontSize="120px" /> : <Staff staff={response} />}
    </Fragment>
  );
}

export default StaffPart;
