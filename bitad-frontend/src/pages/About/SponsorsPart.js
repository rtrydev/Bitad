import Columns from "../../components/UI/Columns";
import Sponsors from "../../components/Sponsors/Sponsors";
import { DUMMY_SPONSORS } from "../../dummy-data/dummyData";

function SponsorsPart() {
  return (
    <Columns reverse={true}>
      <Sponsors sponsors={DUMMY_SPONSORS} />
      <div>
        <h2>
          Konferencja jest
          <br /> możliwa dzięki Nim!
        </h2>
        <p>
          Podjęliśmy się organizacji konferencji Beskid IT Academic Day na
          Akademii Techniczno-Humanistycznej w Bielsku-Białej.
        </p>
        <p>
          Nieustannie staramy się rozwijać nasz event, jednocześnie dbając o to,
          aby uczestnicy, zarówno profesjonaliści, jak i amatorzy, wynieśli z
          tego dnia ogromne pokłady wiedzy.
        </p>
        <p>
          Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o to, aby
          to piątkowe spotkanie.
        </p>
      </div>
    </Columns>
  );
}

export default SponsorsPart;
