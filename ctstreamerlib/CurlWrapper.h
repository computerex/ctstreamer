#ifndef _H_COMPUTEREX_CURL_WRAPPER_H_698a80e199a801f99e74e9a2822def49
#define _H_COMPUTEREX_CURL_WRAPPER_H_698a80e199a801f99e74e9a2822def49

#include <curl/curl.h>

size_t write_data(void *ptr, size_t size, size_t nmemb, FILE *stream);

class CurlWrapper
{
public:
	CurlWrapper();
	~CurlWrapper();
	void uploadFile(char * url, char * filePath, char * file);
	void downloadFile(char* url, char* fname);
	void post(char * url, char* query);
	void get(char* url);
private:
	void initop();
	 CURL *curl;
	 CURLcode res;
};

#endif
