#include <ptypes.h>
#include <pasync.h>
#include <pinet.h>

USING_PTYPES;

tobjlist<ipstream> clients(false);
int i = 0;

class svthread: public thread
{
protected:
	ipstream * c;
	int i;
    virtual void execute()
	{
		while(c->get_active())
		{
			try
			{
				string req = lowercase(c->line(4096));
				req = "[" + itostring(i) + "] => " + req; 
				for(int i = 0; i < clients.get_count(); i++)
				{
					clients[i]->putline(req);
					clients[i]->flush();
				}
			} catch (estream * e)
			{
				delete e;
				break;
			} catch (...) { }
		}
		for(int i = 0; i < clients.get_count(); i++)
		{
			if (clients[i] == c)
			{
				clients.del(i);
				break;
			}
		}
		delete c;
	}
    virtual void cleanup()
	{
		
	}
public:
    svthread(ipstream * client, int ci): thread(false), c(client), i(ci)  {}
	virtual ~svthread() {  }
};

int main()
{
	
	
	tobjlist<thread> threads(true);
	ipstmserver srv;

	srv.bindall(245);

	while(true)
	{
		ipstream * client = new ipstream();
		srv.serve(*client);
		svthread * t = new svthread(client, i);
		threads.add(t);
		t->start();
		i++;
		clients.add(client);
	}
}