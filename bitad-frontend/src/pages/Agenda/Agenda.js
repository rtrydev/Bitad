import SmallHero from "../../components/Hero/SmallHero";
import Section from "../../components/UI/Section";
import EventsPart from "./EventsPart";
import TimelinesPart from "./TimelinesPart";
import { useGetRequest } from "../../hooks/http-requests";

import typography from "../../assets/css/Typography.module.css";
import heroImage from "../../assets/images/bitad-logo-2022.svg";
import Loading from "../../components/UI/Loading";

function Agenda() {
  const { response: agendas, isLoading: isLoadingAgendas } =
    useGetRequest("/Agenda/GetAgendas");
  const { response: workshops, isLoading: isLoadingWorkshops } = useGetRequest(
    "/Workshop/GetWorkshops"
  );

  const events =
    isLoadingAgendas || isLoadingWorkshops ? (
      <Loading fontSize="120px" />
    ) : (
      <>
        <TimelinesPart agendas={agendas} workshops={workshops} />
        <EventsPart agendas={agendas} workshops={workshops} />
      </>
    );

  return (
    <div>
      <SmallHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle={process.env.REACT_APP_SUBTITLE}
        title="Konferencja Informatyczna"
        linkText={
          process.env.REACT_APP_ENABLE_REGISTRATION === "enabled"
            ? process.env.REACT_APP_ENABLED_REGISTRATION_LABEL
            : process.env.REACT_APP_DISABLED_REGISTRATION_LABEL
        }
        linkTo={
          process.env.REACT_APP_ENABLE_REGISTRATION === "enabled"
            ? "/registration"
            : "#"
        }
      />
      <Section id="agenda">
        <h2 className={typography["text-align--center"]}>Agenda</h2>
        {process.env.REACT_APP_AGENDA_SOON ? (
          <p className={typography["text-align--center"]}>
            Jesteśmy w trakcie planowania prelekcji oraz warsztatów. Prosimy o
            chwilę cierpliwości 😃.
          </p>
        ) : (
          events
        )}
      </Section>
    </div>
  );
}

export default Agenda;
