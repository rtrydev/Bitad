import ShortInfo from "../components/ShortInfo/ShortInfo";
import { HashLink } from "react-router-hash-link";

function AccountCreationInfo({
  title = "Konto zostało utworzone",
  description = (
    <>
      Wiadomość z kodem aktywacji konta została wysłana na podany adres mail.
      Dodatkowo możesz pobrać aplikację do Gry QR więcej szczegółów znajdziesz{" "}
      <HashLink to="/details#game">tutaj</HashLink>.
    </>
  ),
}) {
  return <ShortInfo title={title} description={description} />;
}

export default AccountCreationInfo;
