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
          Dzięki sponsorom mamy przyjemność 11 raz organizować dla Was
          konferencję, tym razem tematem przewodnim jest “MaszynoweLove BITAD w
          chmurach”, która urozmaici Wasz czas oraz pomoże rozwinąć
          zainteresowania szeroko pojętym działem IT oraz pogłębić wiedzę
          praktyczną. Jesteśmy wdzięczni za pomoc, dziękujemy! ♥
        </p>
      </div>
    </Columns>
  );
}

export default SponsorsPart;
