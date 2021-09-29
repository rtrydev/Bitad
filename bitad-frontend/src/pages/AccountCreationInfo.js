import ShortInfo from "../components/ShortInfo/ShortInfo";

function AccountCreationInfo({
  title = "Konto zostało utworzone",
  description = "Wiadomość z kodem aktywacji konta została wysłana na podany adres mail",
}) {
  return <ShortInfo title={title} description={description} />;
}

export default AccountCreationInfo;
