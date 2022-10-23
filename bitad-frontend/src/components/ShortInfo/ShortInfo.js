import bg from "../../assets/css/Backgrounds.module.css";
import styles from "../Hero/Hero.module.css";
import typography from "../../assets/css/Typography.module.css";
import Container from "../UI/Container";
import image from "../../assets/images/bitad-logo-2022.svg";
import Loading from "../UI/Loading";

function ShortInfo({ title, description, isLoading = false, children }) {
  const shortMessage = (
    <>
      <h2>{title}</h2>
      {description && <h4>{description}</h4>}
    </>
  );

  return (
    <Container className={bg["hero-background"]}>
      <header className={`${styles.hero} ${typography["text-align--center"]}`}>
        {isLoading && <Loading fontSize="120px" />}
        {!isLoading && shortMessage}
        {!isLoading && children}
        {!isLoading && <img src={image} alt="Logo Bitadu" />}
      </header>
    </Container>
  );
}

export default ShortInfo;
