import Columns from "../../components/UI/Columns";
import Sponsors from "../../components/Sponsors/Sponsors";
import Loading from "../../components/UI/Loading";
import { useGetRequest } from "../../hooks/http-requests";

function SponsorsPart() {
  const { response, isLoading } = useGetRequest("/Sponsor/GetSponsors");

  return (
    <Columns reverse={true}>
      {isLoading ? (
        <Loading fontSize="120px" />
      ) : (
        <Sponsors sponsors={response} />
      )}
      <div>
        <h2>
          Konferencja jest
          <br /> możliwa dzięki Nim!
        </h2>
        <p>
          Staramy się, aby konferencja była wyjątkowym przeżyciem, aby każdy
          mógł zgłębić pasjonujące Go tematy z dziedziny informatyki. Ale sami
          nie dalibyśmy rady... Jesteśmy wdzięczni za Waszą pomoc. Dzięki Wam
          BITAD 2020++ się odbędzie!
        </p>
      </div>
    </Columns>
  );
}

export default SponsorsPart;
