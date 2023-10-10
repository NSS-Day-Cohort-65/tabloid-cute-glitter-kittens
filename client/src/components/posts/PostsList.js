import { useState, useEffect } from "react";
import { getAllPosts } from "../../managers/postManager";
import {
    Accordion,
    AccordionBody,
    AccordionHeader,
    AccordionItem,
} from 'reactstrap';

export default function PostsList() {
    const [posts, setPosts] = useState([]);
    const [open, setOpen] = useState('0');

    useEffect(() => {
        getAllPosts().then(setPosts);
    }, []);

    const toggle = (id) => {
        if (open === id) {
            setOpen('0');
        } else {
            setOpen(id);
        }
    };

    if (!posts.length) {
        return null;
    }
    return (
        <>
            <h1>
                Catty Posts
            </h1>
            <div>
                <Accordion open={open} toggle={toggle}>
                    {/* the below block of code displays post only if isAppoved === true */}
                    {/* {posts.map(p =>
                    p.isApproved ? (
                        <AccordionItem key={p.id}>
                            <AccordionHeader targetId={p.id.toString()}>
                                <strong>{p.title}</strong>&nbsp;&nbsp;&nbsp;&nbsp;{p.userProfile.fullName}&nbsp;&nbsp;&nbsp;&nbsp;<i>#{p.category.name}</i>
                            </AccordionHeader>
                            <AccordionBody accordionId={p.id.toString()}>
                                "insert child component here"
                            </AccordionBody>
                        </AccordionItem>
                    ) : ""
                )} */}
                    {posts.map(p =>
                        <AccordionItem key={p.id}>
                            <AccordionHeader targetId={p.id.toString()}>
                                <strong>{p.title}</strong>&nbsp;&nbsp;&nbsp;&nbsp;{p.userProfile.fullName}&nbsp;&nbsp;&nbsp;&nbsp;<i>#{p.category.name}</i>
                            </AccordionHeader>
                            <AccordionBody accordionId={p.id.toString()}>
                                <div>

                                    <p>Title: {p.title}</p>

                                    <p>{p.imageLocation}</p>
                                    {/* tested: will not show up if it's null */}

                                    <p>Username: {p.userProfile.identityUser.userName}</p>

                                    <p>Content: {p.content}</p>

                                    {/* <p>{p.publishDateTime}</p> */}

                                    <p>Created On: {new Date(p.createDateTime).toLocaleDateString()}</p>
                                    {/* should be published date, but nothing is published yet. */}

                                </div>
                            </AccordionBody>
                        </AccordionItem>
                    )}
                </Accordion>
            </div>
        </>
    )
}