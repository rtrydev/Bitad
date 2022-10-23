import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import bg from "../assets/css/Backgrounds.module.css";
import styles from "../components/Hero/Hero.module.css";
import typography from "../assets/css/Typography.module.css";
import Container from "../components/UI/Container";
import image from "../assets/images/bitad-logo-2022.svg";
import api from "../api/api";
import Loading from "../components/UI/Loading";

function AccountActivation() {
  const { code } = useParams();
  const [isLoading, setIsLoading] = useState(true);
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    setIsLoading(true);
    api
      .put(`/User/ConfirmAccount?confirmCode=${code}`)
      .then(() => {
        setIsError(false);
        setIsLoading(false);
      })
      .catch(() => {
        setIsError(true);
        setIsLoading(false);
      });
  }, [code]);

  const shortMessage = (title, description) => {
    return (
      <>
        <h2>{title}</h2>
        <h4>{description}</h4>
      </>
    );
  };

  const message = isError
    ? shortMessage(
        "Coś poszło nie tak",
        "Możliwe, że już potwierdziłeś swoją obecność"
      )
    : shortMessage(
        "Twoja obecność została potwierdzona",
        process.env.REACT_APP_SECONDARY_SUBTITLE
      );

  return (
    <Container className={bg["hero-background"]}>
      <header className={`${styles.hero} ${typography["text-align--center"]}`}>
        {isLoading && <Loading fontSize="120px" />}
        {!isLoading && message}
        {!isLoading && <img src={image} alt="Logo Bitadu" />}
      </header>
    </Container>
  );
}

export default AccountActivation;
