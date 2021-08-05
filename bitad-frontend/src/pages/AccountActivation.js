import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import bg from "../assets/css/Backgrounds.module.css";
import styles from "../components/Hero/Hero.module.css";
import typography from "../assets/css/Typography.module.css";
import Container from "../components/UI/Container";
import image from "../assets/images/bitad-logo.svg";
import api from "../api/api";
import Loading from "../components/UI/Loading";

function AccountActivation() {
  const { code } = useParams();
  const [isLoading, setIsLoading] = useState(false);
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    setIsLoading(true);
    api
      .put(`/User/ActivateAccount?activationCode=${code}`)
      .then(() => {
        setIsError(false);
      })
      .catch(() => {
        setIsError(true);
      });
    setIsLoading(false);
  }, []);

  const shortMessage = (title, description) => {
    return (
      <>
        <h2>{title}</h2>
        <h4>{description}</h4>
      </>
    );
  };
  return (
    <Container className={bg["hero-background"]}>
      <header className={`${styles.hero} ${typography["text-align--center"]}`}>
        {isLoading && <Loading fontSize="120px" />}
        {isError || isLoading
          ? shortMessage(
              "Coś poszło nie tak",
              "Możliwe, że konto zostało już aktywowane"
            )
          : shortMessage(
              "Konto zostało aktywowane",
              "Zapraszamy na konferencję 20 marca 2020 na uczelni ATH w Bielsku-Białej"
            )}
        {!isLoading && <img src={image} alt="Logo Bitadu" />}
      </header>
    </Container>
  );
}

export default AccountActivation;
